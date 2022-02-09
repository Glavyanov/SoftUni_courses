class Company{
    constructor(){
        this.departments = {};
    }
    addEmployee(username,salary,position, department){
        Array.from(arguments).forEach((x,i) => {
            if (!x) {
                throw new Error('Invalid input!');
            }else if(i == 1 && x < 0){
                throw new Error('Invalid input!');
            }
        });
        if (!this.departments[department]) {
            this.departments[department] = {[username]: {salary,position}};
        }else{
            this.departments[department][username]= {salary,position};
        }
        
        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }
    bestDepartment(){
        let bestDepartment;
        let bestSalaryAverage = 0;
        for (const department in this.departments) {
            let currentAverageSlary = 0;
            for (const name in this.departments[department]) {
                currentAverageSlary += this.departments[department][name].salary;
            }
            currentAverageSlary /= Object.keys(this.departments[department]).length;
            if (bestSalaryAverage < currentAverageSlary) {
                bestSalaryAverage = currentAverageSlary;
                bestDepartment = department;
            }
        }
        let infoBestDepartment = Object.entries(this.departments[bestDepartment]).sort((a,b) => b[1].salary - a[1].salary || a[0].localeCompare(b[0]));
       return `Best Department is: ${bestDepartment}` + '\n' +
               `Average salary: ${bestSalaryAverage.toFixed(2)}` + '\n'+
               `${infoBestDepartment.map(x=> `${x[0]} ${x[1].salary} ${x[1].position}`).join('\n')}`;
    }
}
let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());

