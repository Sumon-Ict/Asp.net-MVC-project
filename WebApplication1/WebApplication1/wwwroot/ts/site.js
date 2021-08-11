var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
console.log('hello from  typescript site file');
var employee = /** @class */ (function () {
    function employee(name, code) {
        this.empname = name;
        this.empcode = code;
    }
    employee.prototype.getsalary = function () {
        return 1001;
    };
    return employee;
}());
var emp = new employee("sumon", 23);
console.log("the employee name is " + emp.empname + "and employee code is " + emp.empcode);
console.log(emp.getsalary());
console.log('my name is sumon');
var employee2 = /** @class */ (function () {
    function employee2() {
    }
    return employee2;
}());
var emp2 = new employee2();
var r = emp2.empname = 'rashid';
emp2.empcode = 345;
console.log(r);
var greater = /** @class */ (function () {
    function greater(message) {
        this.greeting = message;
    }
    greater.prototype.greet = function () {
        return 'hellow ' + this.greeting;
    };
    return greater;
}());
var re = new greater("sumon");
console.log(re.greet());
var Person = /** @class */ (function () {
    function Person(name) {
        this.empname = name;
    }
    return Person;
}());
var employee3 = /** @class */ (function (_super) {
    __extends(employee3, _super);
    function employee3(code, name) {
        var _this = _super.call(this, name) || this;
        _this.empcode = code;
        return _this;
    }
    employee3.prototype.display = function () {
        console.log('empoyee name :' + this.empname + "employee code :" + this.empcode);
    };
    return employee3;
}(Person));
var emp3 = new employee3(234, 'kajol');
emp3.display();
var Employee = /** @class */ (function () {
    function Employee(empcode2, name2) {
        this.empCode = empcode2;
        this.name = name2;
    }
    Employee.prototype.display = function () {
        console.log("Name = " + this.name + ", Employee Code = " + this.empCode);
    };
    return Employee;
}());
var per = new Employee(100, "Bill");
function printlabel(labelobject) {
    console.log(labelobject.label2);
    console.log(labelobject.age);
}
var myoj = { label2: 'sumon', age: 90, weight: 67, name: 'kajol' };
printlabel(myoj);
function print2(labelob) {
    console.log(labelob.Name);
    console.log(labelob.age);
    console.log(labelob.weight);
}
var ob = { Name: 'kalam', age: 765, weight: 876 };
print2(ob);
var iformation = { home: 'bogura', code: 789 };
var i2 = { home: 'kushtia', code: 876 };
console.log(i2.home);
console.log(i2.code);
var Animal = /** @class */ (function () {
    function Animal() {
    }
    Animal.prototype.move = function (distanceinmeter) {
        if (distanceinmeter === void 0) { distanceinmeter = 0; }
        // console.log('animal move ${distanceinmeter}m');
        console.log(distanceinmeter);
    };
    return Animal;
}());
var dog = /** @class */ (function (_super) {
    __extends(dog, _super);
    function dog() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    dog.prototype.bark = function () {
        console.log('wolf wolf ');
    };
    dog.prototype.eat = function (name) {
        //console.log('animal eating name is ${name}');
        console.log('animal eating name is ' + name);
    };
    return dog;
}(Animal));
var d = new dog();
d.catagory = 'cat';
d.move(12);
d.bark();
d.eat('rice');
console.log('the animal catagory is ' + d.catagory);
var Animal2 = /** @class */ (function () {
    function Animal2(name) {
        this.Name = name;
    }
    Animal2.prototype.move = function (distance) {
        if (distance === void 0) { distance = 0; }
        console.log('distance is ' + distance);
    };
    return Animal2;
}());
var tiger = /** @class */ (function (_super) {
    __extends(tiger, _super);
    function tiger(Name) {
        return _super.call(this, Name) || this;
    }
    tiger.prototype.move = function (distance) {
        if (distance === void 0) { distance = 5; }
        console.log('distance mesured ');
        _super.prototype.move.call(this, distance);
    };
    return tiger;
}(Animal2));
var horse = /** @class */ (function (_super) {
    __extends(horse, _super);
    function horse(Name) {
        return _super.call(this, Name) || this;
    }
    horse.prototype.move = function (distance) {
        if (distance === void 0) { distance = 890; }
        console.log('distance of horse class');
        _super.prototype.move.call(this, distance);
    };
    return horse;
}(Animal2));
var ti = new tiger("tiger");
console.log(ti.Name);
console.log(ti.move(234));
var A2 = new horse("Horse");
console.log(A2.Name);
console.log(A2.move(1000));
var A3 = new horse("horse3");
console.log(A3.Name);
console.log(A3.move(2000));
//accessilbility  code
var Animal3 = /** @class */ (function () {
    function Animal3(name) {
        this.Name = name;
    }
    Animal3.prototype.move = function (distance) {
        if (distance === void 0) { distance = 0; }
        console.log('animal distance is' + distance);
    };
    return Animal3;
}());
var ob2 = new Animal3('Tiger');
console.log(ob2.Name);
var Animal4 = /** @class */ (function () {
    function Animal4(name) {
        this.Name = name;
    }
    Animal4.prototype.move = function (distance) {
        if (distance === void 0) { distance = 0; }
        console.log('animal distance is ' + distance);
    };
    return Animal4;
}());
var ob4 = new Animal4('Horse');
console.log(ob4.move(123));
var rhino = /** @class */ (function (_super) {
    __extends(rhino, _super);
    function rhino() {
        return _super.call(this, 'mate') || this;
    }
    return rhino;
}(Animal4));
var ob5 = new rhino();
console.log(ob5.move(90));
var person = /** @class */ (function () {
    function person(name) {
        this.Name = name;
    }
    return person;
}());
var person2 = /** @class */ (function (_super) {
    __extends(person2, _super);
    function person2(Name, deptname) {
        var _this = _super.call(this, Name) || this;
        _this.deptname = deptname;
        return _this;
    }
    person2.prototype.display = function () {
        console.log('person name ' + this.Name);
        console.log('dept of person ' + this.deptname);
    };
    return person2;
}(person));
var ob6 = new person2('sumon', 'Ict');
ob6.display();
function createSquare(config) {
    var newSquare = { color: "white", area: 100 };
    if (config.color) {
        newSquare.color = config.color;
    }
    if (config.width) {
        newSquare.area = config.width * config.width;
    }
    return newSquare;
}
var mySquare = createSquare({ color: "black" });
console.log(mySquare.area);
console.log(mySquare.color);
function createsquare(inputob) {
    var newsquare = { color: 'white', area: 0 };
    if (inputob.color) {
        newsquare.color = inputob.color;
    }
    if (inputob.width) {
        newsquare.area = inputob.width * inputob.width;
    }
    return newsquare;
}
var mysquare = createsquare({ color: "red" }); //only one argument is passing 
console.log(mysquare.color);
console.log(mysquare.area);
var mysquare2 = createsquare({ color: 'white', width: 198 }); //both argument are passing
console.log(mysquare2.area);
var mysquare3 = createsquare({}); //no argument is passing 
console.log(mysquare3.color); //default color is displayed
var octopus = /** @class */ (function () {
    function octopus(name) {
        this.numberoflegs = 8;
        this.Name = name;
    }
    return octopus;
}());
var oct = new octopus('Octopus');
console.log(oct.Name);
var res = { 'enable': true, 'disable': false };
console.log(res);
console.log(res['enable']);
var strarr = { 0: 'sumon', 2: 'rafik', 9: 'kajol' };
console.log(strarr);
console.log(strarr[9]);
var str2 = ["sumon", 'sujon', 'suvo'];
console.log(str2);
console.log(str2[2]);
var dic = ['dhaka', 'rajshahi', 'kushtia'];
console.log(dic);
console.log(dic.length);
console.log(dic.pop());
//let numberst: NumberOrStringDictionary = { 'imran': 90, 'kajol': 234, 'suvo': 'sumon' };
//console.log(numberst);
var worker = /** @class */ (function () {
    function worker() {
    }
    return worker;
}());
var workman = new worker();
workman.Name = "sumon";
if (workman.Name) {
    console.log(workman.Name);
}
var maxlenthofname = 12;
var worker2 = /** @class */ (function () {
    function worker2() {
    }
    Object.defineProperty(worker2.prototype, "fullname", {
        get: function () {
            return this._name;
        },
        set: function (setname) {
            if (setname && setname.length > maxlenthofname) {
                throw new Error('fullname has a max lentgh ' + maxlenthofname);
            }
            this._name = setname;
        },
        enumerable: false,
        configurable: true
    });
    return worker2;
}());
var workman2 = new worker2();
workman2.fullname = 'sumon';
console.log(workman2.fullname);
var Circle = /** @class */ (function () {
    function Circle() {
    }
    Circle.calculatearea = function (radi) {
        return this.pi * radi * radi;
    };
    Circle.pi = 3.1416;
    return Circle;
}());
console.log(Circle.pi);
var circleA = Circle.calculatearea(4);
console.log(circleA);
var circle = /** @class */ (function () {
    function circle() {
        this.pi = 908;
    }
    circle.pi = 3.1416;
    return circle;
}());
console.log(circle.pi); //static value print  
var cir = new circle();
console.log(cir.pi); //non static value print
var person4 = /** @class */ (function () {
    function person4() {
    }
    person4.prototype.display = function () {
        console.log(this.name);
    };
    return person4;
}());
var workman3 = /** @class */ (function (_super) {
    __extends(workman3, _super);
    function workman3(name, code) {
        var _this = _super.call(this) || this;
        _this.name = name;
        _this.empcode = code;
        return _this;
    }
    return workman3;
}(person4));
var info = new workman3('sumon', 890); //or let info:person4=new workman3('sumon',890);
console.log(info.display());
//generic code 
function genericsarr(item) {
    return new Array().concat(item);
}
var numarr = genericsarr([12, 78, 908]);
var namearr = genericsarr(['sumon', 'sujon', 'suvo']);
console.log(numarr);
console.log(namearr);
function Garr(item) {
    return new Array().concat(item);
}
var Num = Garr(['bangla', 'english', 'mathematics']);
Num.push('arabic');
console.log(Num);
var stringarr = Garr([78, 98, 456]);
stringarr.push(987);
console.log(stringarr.length);
function identity(arr) {
    return arr;
}
var ident = identity(78);
console.log(ident);
function generics(arg) {
    return arg;
}
var output = generics('laptop');
console.log(output);
var person5 = /** @class */ (function () {
    function person5(fname, lname) {
        this.firstname = fname;
        this.lastname = lname;
    }
    return person5;
}());
function display(per) {
    console.log(per.firstname + " " + per.lastname);
}
var p = new person5('md', 'sumon');
display(p);
var x = 23, y = 90, z = 123;
if (x > y) {
    console.log('x is greater than y');
}
else if (x < y) {
    console.log('x is less than y');
}
console.log("z value :" + z);
//# sourceMappingURL=site.js.map