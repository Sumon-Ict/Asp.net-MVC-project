let message: string = 'Hello World';
console.log(message);

let blvalue: boolean = false;
console.log(blvalue);

let decimalval: number = 123;
console.log(decimalval);

var binaryv: number = 11010;
console.log(binaryv);

let color: string = "blue";
color = "red";
let list: Number[] = [1, 2, 45];
console.log(list);

let list1: Array<number> = [2, 4, 5];
console.log(list1);

let tple: [string, number];
tple = ["sumon", 234];
console.log(tple[1]);
console.log(tple[0].substring(2, 4));
console.log(tple[1].toString());


//number method operation example 
let myNumber: number = 123456;

myNumber.toExponential(); // returns 1.23456e+5
myNumber.toExponential(1); //returns 1.2e+5


let myNumber2: number = 10.8788;

myNumber2.toFixed(); // returns 11
myNumber2.toFixed(1); //returns 10.9
myNumber2.toFixed(2); //returns 10.88

let myNumber3: number = 10667.987;

myNumber3.toLocaleString(); // returns 10,667.987 - US English
myNumber3.toLocaleString('de-DE'); // returns 10.667,987 - German
myNumber3.toLocaleString('ar-EG'); // returns 10667.987 in Arebic


let myNumber4: number = 10.5679;

myNumber4.toPrecision(1); // returns 1e+1
myNumber4.toPrecision(2); // returns 11
myNumber4.toPrecision(3); // returns 10.6
myNumber4.toPrecision(4); // returns 10.57

let myNumber5: number = 123;   // 
myNumber5.toString(); // returns '123'
myNumber5.toString(2); // returns '1111011'  //convert 2 base number 
myNumber5.toString(4); // returns '1323'       
myNumber5.toString(8); // returns '173'  //convert 8 base number 


let Name: string = "sumon";

let Id: number = 123;

let address: string = 'the name of student is ${Name} and  id no is ${Id}';

enum students {
    sumon,
    sujon,
    suvo,
    kajol

}
let studentName: students = students.sumon;

let studentName2: string = students[1];

let fruits: string[] = ["apple", "mango", "jackfruits"];

for (let index in fruits) {
    console.log(fruits[index]);

}


let fruits1: Array<string> = ["apple", "mango", "banana"];

let information: (string | number)[] = ["apple", 23, "mango", 90, 65];

for (let i in information)
{
    console.log(information[i]);

}


//array exmaple
let address1: Array<string | number> = ['sumon', 87, 'sujon', 87, 'kajol'];

let tple2: [string, number] = ["sumon", 123];

let tplarray: [string, number][] = [['sumon', 12], ['suvo', 90], ['kajol', 87]];

console.log(tplarray[1][0]);

tple2.push('imran');

for (let i in tple2) {
    console.log(tple2[i]);

}

//enum example 

enum students {
    titu = 12,
    rashid,
    imran,
    sumi

}


function gethome(home: string): students {
    if (home == "kusthia" || home == "meherpur")

        return students.imran;
}

let district: students = gethome("kusthia");

console.log(district);


enum address2 {
    name = "sohag",
    home = "bogura",
    careof = 'siragul',
    village = "mulbari",
    nationality="Bangladesh"

}

console.log(address2.nationality);
console.log(address2["village"]);

//union uses code
function displaytype(value: (string | Number)) {
    if (typeof (value) === 'string')
        console.log("datatype is string");
    else if (typeof (value) === 'number')
        console.log('type is number');
}

displaytype(123);
displaytype("sumon");



//datatype any uses 

let anyvalue: any = 'sumon';
anyvalue = 234;
anyvalue = false;

let value: any = 34;
console.log(value.toFixed());


let list2: any[] = ['sumon', 89, false, 67.90];
list2[2] = 'kajol';
console.log(list2[3]);

function warnUser(): void {
    console.log('this is user waning message');

}

let usermessage: void = warnUser();

console.log(usermessage);



   //create(123);  not ok cause value does not object or null type


//type assertion

let somevalue: any = 123;
let gettype = <number>somevalue;

console.log(typeof(gettype));

let somestring: any = "my name is sumon";

let lenth: number = (<string>somestring).length;

console.log(lenth);

let str: any = "sumon";

let gett = <string>str;
console.log(gett);



console.log("test demo");



































