"use strict"
number = 11;
var number = 5;
console.log(number);
var number = 6;
console.log(number);


const num3 = 5;

let num4 = "jerry", num5 = 36;
console.log(num4 + " is " + num5 + " years old.");
num4 = 56;
console.log(num4);
let num6 = "Jenny";
console.log("Mark is not " + num6);

let num7;
console.log(num7);

let user = {
    name: "Kevin",
    age: 41,
};

console.log(user.name);

let user1 = {};
console.log(user1);
user1.name = "jim";
console.log(user1.name);
user1.anotherObject = {sides: 4, color: "blue"};
console.log(user1.anotherObject.sides);
console.log(user1.anotherObject.color);
user1.id = 321;
user.id = Symbol("id");
console.log(user1.id);
let user2 = {id : 322};
console.log(user2.id);

let user4 = { n: number};
let user3 =  { n: number};

console.log(user4 == user3);
console.log(user4 === user3);

let result = 10 /(3 + 2) * 4 + 5 ** 2 + 6 - 9;
console.log(result);

let obj = {
    name: "kevin",
    age: 20,
    height: "6-1"
};

console.log(obj);
let jsonObj = JSON.stringify(obj)

console.log(jsonObj);

console.log(jsonObj.charAt(7))

let obj1 = JSON.parse(jsonObj);
console.log(obj1);


let p = document.getElementsByTagName("p");
p[0].textContent = "This text is changed ";
p[0].style.color = "orange"

let h1s = document.getElementsByTagName("h1");
h1s[0].style.color = "pink";
h1s[1].style.color = "pink";

let h1id = document.getElementById("h1id");
h1id.style.color = "brown"

let bodyChild = document.body.childNodes;

bodyChild[2].textContent = "This is the text change"

let body = document.body;
let newNode = document.createElement("p");
newNode.textContent = "This is a new node and child of the body";

body.appendChild(newNode);

newNode.addEventListener('mouseover', () => (newNode.style.color = "red"));
newNode.addEventListener('mouseout', () => (newNode.style.color = "black"));