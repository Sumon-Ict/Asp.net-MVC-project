console.log('hello from  typescript site file');

class employee {

    empname: string;
    empcode: number;

    constructor(name: string, code: number) {

        this.empname = name;
        this.empcode = code;

    }

    getsalary(): number {
        return 1001;


    
    }
}

let emp = new employee("sumon", 23);
console.log("the employee name is " + emp.empname + "and employee code is " + emp.empcode);

console.log(emp.getsalary());

console.log('my name is sumon');


class employee2 {
    empname: string;
    empcode: number;

}

let emp2 = new employee2();

  let r=  emp2.empname = 'rashid';
    emp2.empcode = 345;

console.log(r);

class greater {
    greeting: string;

    constructor(message: string) {
        this.greeting = message;
    }

    greet() {
        return 'hellow ' + this.greeting;
    }
}

let re = new greater("sumon");
console.log(re.greet());


class Person {
    empname: string;

    constructor(name: string) {
        this.empname = name;

    }

    
}
class employee3 extends Person {
    empcode: number;

    constructor(code: number, name: string) {
        super(name);
        this.empcode = code;
    }
    display(): void {
        console.log('empoyee name :' + this.empname + "employee code :" + this.empcode);

    }

}
let emp3 = new employee3(234, 'kajol');
emp3.display();




interface IPerson {
    name: string;
    display(): void;
}



interface IEmployee {
    empCode: number;
}

class Employee implements IPerson, IEmployee {
    empCode: number;
    name: string;

    constructor(empcode2: number, name2: string) {
        this.empCode = empcode2;
        this.name = name2;
    }

    display(): void {
        console.log("Name = " + this.name + ", Employee Code = " + this.empCode);
    }
}

let per: IPerson = new Employee(100, "Bill");


function printlabel(labelobject: { label2: string, age: number }) {
    console.log(labelobject.label2);
    console.log(labelobject.age);

}

let myoj = { label2: 'sumon',age:90,weight:67,name:'kajol'};
printlabel(myoj);


interface information {
    Name: string;
    age: number;
    weight: number;
}
function print2(labelob: information) {
    console.log(labelob.Name);
    console.log(labelob.age);
    console.log(labelob.weight);

}

let ob = { Name: 'kalam', age: 765, weight: 876 };
print2(ob);


 //interface act as a return type
interface Iinformation {
    home: string;
    code: number;
}
let iformation: Iinformation = { home: 'bogura', code: 789 };

let i2: Iinformation = { home: 'kushtia', code: 876 };

console.log(i2.home);
console.log(i2.code);


class Animal {
    catagory: string;
    move(distanceinmeter: number=0) {
        // console.log('animal move ${distanceinmeter}m');
        console.log(distanceinmeter);



    }
}

class dog extends Animal {
    bark() {
        console.log('wolf wolf ');

    }
    eat(name: string) {
        //console.log('animal eating name is ${name}');
        console.log('animal eating name is ' + name);
    }
}

let d = new dog();
d.catagory = 'cat';

d.move(12);
d.bark();
d.eat('rice');

console.log('the animal catagory is ' + d.catagory);

class Animal2 {
    Name: string;
    constructor(name: string) {
        this.Name = name;
    }

    move(distance: number = 0) {
        console.log('distance is ' + distance);

    }
}
class tiger extends Animal2 {
    constructor(Name: string) {
        super(Name);
    }

    move(distance = 5) {
        console.log('distance mesured ')
        super.move(distance);

    }
}
class horse extends Animal2 {
    constructor(Name: string) {
        super(Name);
    }

    move(distance = 890) {
        console.log('distance of horse class');
        super.move(distance);

    }
}
let ti = new tiger("tiger");
console.log(ti.Name);

console.log(ti.move(234));

let A2 = new horse("Horse");
console.log(A2.Name);
console.log(A2.move(1000));

let A3: Animal2 = new horse("horse3");
console.log(A3.Name);
console.log(A3.move(2000));


//accessilbility  code

class Animal3 {
    public Name: string;

    public constructor(name: string) {
        this.Name = name;
    }
    public move(distance: number = 0) {
        console.log('animal distance is' + distance);

    }
}

let ob2 = new Animal3('Tiger');
console.log(ob2.Name);


class Animal4 {
    private Name: string;

    constructor(name: string) {
        this.Name = name;
    }
    move(distance: number = 0) {
        console.log('animal distance is ' + distance);

    }

}

let ob4 = new Animal4('Horse');
console.log(ob4.move(123));

class rhino extends Animal4 {
    constructor() {
        super('mate');
    }

}

let ob5 = new rhino();
console.log(ob5.move(90));

class person {
    protected Name: string;

    constructor(name: string) {
        this.Name = name;
    }
}

class person2 extends person {

    private deptname: string;

    constructor(Name: string, deptname: string) {
        super(Name);
        this.deptname = deptname;
    }

    display() {
        console.log('person name ' + this.Name);
        console.log('dept of person ' + this.deptname);

    }

}

let ob6 = new person2('sumon', 'Ict');
ob6.display();

interface SquareConfig {
    color?: string;
    width?: number;
}

function createSquare(config: SquareConfig): { color: string; area: number }
{
    let newSquare = { color: "white", area: 100 };
    if (config.color) {
        newSquare.color = config.color;
    }
    if (config.width) {
        newSquare.area = config.width * config.width;
    }
    return newSquare;
}

let mySquare = createSquare({ color: "black" });

console.log(mySquare.area);
console.log(mySquare.color);

interface squareconfig {
    color?: string;

    width?: number;

}

function createsquare(inputob: squareconfig): { color: string, area: number }
{

    let newsquare = { color: 'white', area:0 };
    if (inputob.color) {
        newsquare.color = inputob.color;
            
    }
    if (inputob.width) {
        newsquare.area = inputob.width * inputob.width;

    }

    return newsquare;

}

let mysquare = createsquare({ color: "red" });  //only one argument is passing 
console.log(mysquare.color);
console.log(mysquare.area);

let mysquare2 = createsquare({ color: 'white', width: 198 });  //both argument are passing

console.log(mysquare2.area);

let mysquare3 = createsquare({});  //no argument is passing 

console.log(mysquare3.color);  //default color is displayed

class octopus {
    readonly Name: string;

    readonly numberoflegs: number = 8;
    constructor(name: string) {
        this.Name = name;
    }

}
let oct = new octopus('Octopus');
console.log(oct.Name);

//indexer code 

interface states {
    [state: string]: boolean;
}

let res: states = { 'enable': true, 'disable': false };

console.log(res);
console.log(res['enable']);

interface stringarray {
    [index: number]: string;
}

let strarr: stringarray = { 0: 'sumon', 2: 'rafik', 9: 'kajol' };

console.log(strarr);

console.log(strarr[9]);

let str2: stringarray = ["sumon", 'sujon', 'suvo'];

console.log(str2);
console.log(str2[2]);


interface dictionaryarr {
    [index: number]: string;
    length: number;
    pop(): string;    

}

let dic: dictionaryarr = ['dhaka', 'rajshahi', 'kushtia'];

console.log(dic);
console.log(dic.length);
console.log(dic.pop());


interface numberorstring {
    [index: string]: string | number;
    length: number;
    //name: string;

}

interface NumberOrStringDictionary {
    [index: string]: number | string;
    length: number; 
    name: string; 
}

//let numberst: NumberOrStringDictionary = { 'imran': 90, 'kajol': 234, 'suvo': 'sumon' };

//console.log(numberst);

class worker {
    Name: string;

}

let workman = new worker();
workman.Name = "sumon";

if (workman.Name) {
    console.log(workman.Name);

}

const maxlenthofname = 12;
class worker2 {
    private _name: string;


    get fullname(): string {
        return this._name;

    }
    set fullname(setname: string) {
        if (setname && setname.length > maxlenthofname) {
            throw new Error('fullname has a max lentgh ' + maxlenthofname);

        }
        this._name = setname;

    }
}
let workman2 = new worker2();
workman2.fullname = 'sumon';

console.log(workman2.fullname);

class Circle {
    static pi: number = 3.1416;

    static calculatearea(radi: number): number {
        return this.pi * radi * radi;
    }
}

console.log(Circle.pi);

let circleA = Circle.calculatearea(4);

console.log(circleA);

class circle {
    static pi: number = 3.1416;

    pi = 908;

}

console.log(circle.pi);  //static value print  

let cir = new circle();
console.log(cir.pi);  //non static value print


abstract class person4 {
    abstract name: string;

    display(): void {
        console.log(this.name);

    }

}
class workman3 extends person4 {

    name: string;
    empcode: number;

    constructor(name: string, code: number) {
        super();
        this.name = name;
        this.empcode = code;
    }

}
let info = new workman3('sumon', 890);  //or let info:person4=new workman3('sumon',890);
console.log(info.display());


//generic code 

function genericsarr(item: any[]): any[] {
    return new Array().concat(item);
}

let numarr = genericsarr([12, 78, 908]);

let namearr = genericsarr(['sumon', 'sujon', 'suvo']);

console.log(numarr);
console.log(namearr);

function Garr<T>(item: T[]): T[] {
    return new Array().concat(item);

}

let Num = Garr<string>(['bangla', 'english', 'mathematics']);

Num.push('arabic');

console.log(Num);
let stringarr = Garr<number>([78, 98, 456]);
stringarr.push(987);

console.log(stringarr.length);

function identity(arr: number): number {
    return arr;
}
let ident = identity(78);
console.log(ident);

function generics<T>(arg: T): T {
    return arg;
}

let output = generics<string>('laptop');
console.log(output);

class person5 {
    firstname: string;
    lastname: string;

    constructor(fname: string, lname: string) {
        this.firstname = fname;
        this.lastname = lname;

    }
}

function display<T extends person5>(per: T): void {
    
    console.log(`${per.firstname} ${per.lastname}`);

}

let p = new person5('md', 'sumon');
display(p);

let x: number = 23, y = 90, z = 123;

if (x > y) {
    console.log('x is greater than y');

}
else if (x < y) {
    console.log('x is less than y');

}
console.log(`z value :${z}`);













































































    