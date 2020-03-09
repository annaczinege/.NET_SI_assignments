// Deafult export: import ... from '';
// Named export: import { ... } from '';

import { Person } from "./Person";

export function promote() {}

export default class Teacher extends Person {
  constructor(name, degree) {
    super(name);
    this.degree = degree;
  }

  teach() {
    console.log("teach");
  }
}
