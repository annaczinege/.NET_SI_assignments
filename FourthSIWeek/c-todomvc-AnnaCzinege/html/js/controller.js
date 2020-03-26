class Controller {

    /**
     * @param {!View} view A View instance
     */
    constructor(view) {
        Controller.GET = "GET";
        Controller.POST = "POST";
        Controller.PUT = "PUT";
        Controller.DELETE = "DELETE";

        this.view = view;
        this._activeState = '';
        this._lastActiveState = null;

        view.bindAddItem(this.addItem.bind(this));
        view.bindEditItemSave(this.editItemSave.bind(this));
        view.bindEditItemCancel(this.editItemCancel.bind(this));
        view.bindRemoveItem(this.removeItem.bind(this));
        view.bindToggleItem(this.toggleCompleted.bind(this));
        view.bindRemoveCompleted(this.removeCompletedItems.bind(this));
        view.bindToggleAll(this.toggleAll.bind(this));

        view.bindFilterAll(this.updateState.bind(this));
        view.bindFilterActive(this.updateState.bind(this));
        view.bindFilterComplete(this.updateState.bind(this));

        this.updateState(View.STATE_ALL);
    }

    /**
     * Updates the list if needed
     * @param newState 'all' or 'completed' or 'active', stored in View.STATE_XX
     */
    updateState(newState) {
        this._activeState = newState;
        this._refresh();
        this.view.updateFilterButtons(newState);
    }


    /**
     * Sends an AJAX request.
     * @param endpoint The endpoint of the request, for example "/login"
     * @param method Request method. Can be "GET", "POST", "PUT", "DELETE",..
     * @param data Data to send in the request body
     * @param onSuccess A function to call when the request completes successfully.
     *                  The data will be in event.target.response
     */
    sendAjax(endpoint, method, data = null, onSuccess = null) {
        const scope = this;
        const req = new XMLHttpRequest();
        req.addEventListener("load", function (event) {
            onSuccess.call(scope, event);
        });
        req.addEventListener("error", function (err) {
            console.log("Request failed for " + endpoint + " error: " + err);
        });
        req.open(method, endpoint);
        if (method === Controller.POST || method === Controller.PUT) {
            req.setRequestHeader("Content-type", "application/json; charset=utf-8");
        }
        req.send(data);
    }

    /**
     * Cancel the item editing mode and get the original item from the server.
     */
    editItemCancel(id) {
        this.sendAjax("api/todo/" + id, Controller.GET, null, function (event) {
            const respObj = JSON.parse(event.target.response);
            this.view.editItemDone(id, respObj.name);
        });
    }

    /**
     * Add a new item.
     * NOTE: it easily breaks if the title contains a double quote character
     */
    addItem(title) {
        this.sendAjax("api/todo", Controller.POST, '{"name":"' + title + '", "isComplete":false}', function (event) {
            this.view.clearNewTodo();
            this._refresh(true);
        });
    }

    /**
     * Update an item.
     * NOTE: it easily breaks if the title contains a double quote character
     */
    editItemSave(id, title, isComplete) {
        if (title.length) {
            this.sendAjax("api/todo/" + id, Controller.PUT, '{"id":' + id + ', "name":"' + title + '", "isComplete":"' + isComplete + '"}', function (event) {
                this.view.editItemDone(id, title);
            });
        } else {
            this.removeItem(id);
        }
    }

    /**
     * Delete the data and elements related to an Item.
     */
    removeItem(id) {
        this.sendAjax("api/todo/" + id, Controller.DELETE, null, function (event) {
            this.view.removeItem(id);
        });
    }

    /**
     * Remove all completed items.
     */
    removeCompletedItems() {
        this.sendAjax("api/todo/completed", Controller.DELETE, null, function (event) {
            this._refresh(true);
        });
    }

    /**
     * Update an item's completed state.
     */
    toggleCompleted(id, isComplete) {
        this.sendAjax("api/todo/" + id + "/toggle_status", Controller.POST, '{"status":' + isComplete + '}', function (event) {
            this._refresh(true);
        });
    }

    /**
     * Set all items to complete or incomplete.
     */
    toggleAll(isComplete) {
        this.sendAjax("api/todo/toggle_all", Controller.POST, '{"toggle_all":' + isComplete + '}', function (event) {
            this._refresh(true);
        });
    }

    /**
     * Refresh the list based on the current route.
     * It sends the current status too in the status parameter.
     */
    _refresh(force) {
        const state = this._activeState;

        if (force || this._lastActiveState !== '' || this._lastActiveState !== state) {
            // a response looks like: [{"id":23, "title":"something", "isComplete":true},...]
            this.sendAjax(`api/todo/?status=${state}`, Controller.GET, null, function (event) {
                const respObj = JSON.parse(event.target.response);

                this.view.showItems(respObj);

                const total = respObj.length;
                const completed = respObj.filter(item => item.isComplete === true).length;
                const active = total - completed;

                this.view.setItemsLeft(active);
                this.view.setClearCompletedButtonVisibility(completed > 0);

                this.view.setCompleteAllCheckbox(completed === total);
                this.view.setMainVisibility(total > 0);
            });
        }
        this._lastActiveState = state;
    }
}
