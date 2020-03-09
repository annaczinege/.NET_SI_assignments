import Teacher, { promote } from "./Teacher";
// var scope: function
// let scope: block
// const scope: block

const person = {
  name: "Mosh",
  walk() {
    console.log(this);
  }
};

person.walk();

// bind a function to an object (functions are objects in js)
const walk = person.walk.bind(person);
walk();

// arrow functions
const square = function(number) {
  return number * number;
};

const square2 = number => number * number;
console.log(square2(5));

const jobs = [
  { id: 1, isActive: true },
  { id: 2, isActive: true },
  { id: 3, isActive: false }
];

const activeJobs = jobs.filter(function(job) {
  return job.isActive;
});
const activeJobs2 = jobs.filter(job => job.isActive);
console.log(activeJobs2);

// arrow funstions don't rebind 'this'
const human = {
  talk() {
    setTimeout(() => {
      console.log("this", this);
    }, 1000);
  }
};

human.talk();

// map arrays
const colors = ["red", "green", "blue"];
const items = colors.map(color => `<li>${color}</li>`); // template literal
console.log(items);

// Object destructuring
const address = {
  street: "",
  city: "",
  country: ""
};
// not address.street, address.city, but...
const { street, city, country } = address;

//Spread operator
const first = [1, 2, 3];
const second = [4, 5, 6];

const combined = [...first, "a", ...second];

const clone = [...first];

const third = { name: "Mosh" };
const fourth = { job: "Instructor" };

const combined2 = { ...third, ...fourth, location: "Australia" };
console.log(combined2);

// Class

//Inheritance
const teacher = new Teacher("Mosh", "MSc");
teacher.talk();
