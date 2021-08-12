var message = 'Hello World';
console.log(message);
var blvalue = false;
console.log(blvalue);
var decimalval = 123;
console.log(decimalval);
var binaryv = 11010;
console.log(binaryv);
var color = "blue";
color = "red";
var list = [1, 2, 45];
console.log(list);
var list1 = [2, 4, 5];
console.log(list1);
var tple;
tple = ["sumon", 234];
console.log(tple[1]);
console.log(tple[0].substring(2, 4));
console.log(tple[1].toString());
//number method operation example 
var myNumber = 123456;
myNumber.toExponential(); // returns 1.23456e+5
myNumber.toExponential(1); //returns 1.2e+5
var myNumber2 = 10.8788;
myNumber2.toFixed(); // returns 11
myNumber2.toFixed(1); //returns 10.9
myNumber2.toFixed(2); //returns 10.88
var myNumber3 = 10667.987;
myNumber3.toLocaleString(); // returns 10,667.987 - US English
myNumber3.toLocaleString('de-DE'); // returns 10.667,987 - German
myNumber3.toLocaleString('ar-EG'); // returns 10667.987 in Arebic
var myNumber4 = 10.5679;
myNumber4.toPrecision(1); // returns 1e+1
myNumber4.toPrecision(2); // returns 11
myNumber4.toPrecision(3); // returns 10.6
myNumber4.toPrecision(4); // returns 10.57
var myNumber5 = 123; // 
myNumber5.toString(); // returns '123'
myNumber5.toString(2); // returns '1111011'  //convert 2 base number 
myNumber5.toString(4); // returns '1323'       
myNumber5.toString(8); // returns '173'  //convert 8 base number 
var Name = "sumon";
var Id = 123;
var address = 'the name of student is ${Name} and  id no is ${Id}';
var students;
(function (students) {
    students[students["sumon"] = 0] = "sumon";
    students[students["sujon"] = 1] = "sujon";
    students[students["suvo"] = 2] = "suvo";
    students[students["kajol"] = 3] = "kajol";
})(students || (students = {}));
var studentName = students.sumon;
var studentName2 = students[1];
var fruits = ["apple", "mango", "jackfruits"];
for (var index in fruits) {
    console.log(fruits[index]);
}
var fruits1 = ["apple", "mango", "banana"];
var information = ["apple", 23, "mango", 90, 65];
for (var i in information) {
    console.log(information[i]);
}
//array exmaple
var address1 = ['sumon', 87, 'sujon', 87, 'kajol'];
var tple2 = ["sumon", 123];
var tplarray = [['sumon', 12], ['suvo', 90], ['kajol', 87]];
console.log(tplarray[1][0]);
tple2.push('imran');
for (var i in tple2) {
    console.log(tple2[i]);
}
//enum example 
(function (students) {
    students[students["titu"] = 12] = "titu";
    students[students["rashid"] = 13] = "rashid";
    students[students["imran"] = 14] = "imran";
    students[students["sumi"] = 15] = "sumi";
})(students || (students = {}));
function gethome(home) {
    if (home == "kusthia" || home == "meherpur")
        return students.imran;
}
var district = gethome("kusthia");
console.log(district);
var address2;
(function (address2) {
    address2["name"] = "sohag";
    address2["home"] = "bogura";
    address2["careof"] = "siragul";
    address2["village"] = "mulbari";
    address2["nationality"] = "Bangladesh";
})(address2 || (address2 = {}));
console.log(address2.nationality);
console.log(address2["village"]);
//union uses code
function displaytype(value) {
    if (typeof (value) === 'string')
        console.log("datatype is string");
    else if (typeof (value) === 'number')
        console.log('type is number');
}
displaytype(123);
displaytype("sumon");
//datatype any uses 
var anyvalue = 'sumon';
anyvalue = 234;
anyvalue = false;
var value = 34;
console.log(value.toFixed());
var list2 = ['sumon', 89, false, 67.90];
list2[2] = 'kajol';
console.log(list2[3]);
function warnUser() {
    console.log('this is user waning message');
}
var usermessage = warnUser();
console.log(usermessage);
//create(123);  not ok cause value does not object or null type
//type assertion
var somevalue = 123;
var gettype = somevalue;
console.log(typeof (gettype));
var somestring = "my name is sumon";
var lenth = somestring.length;
console.log(lenth);
var str = "sumon";
var gett = str;
console.log(gett);
console.log("test demo");
//# sourceMappingURL=demo.js.map