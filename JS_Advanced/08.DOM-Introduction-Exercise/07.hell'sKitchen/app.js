function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {

      let input = document.querySelector('#inputs textarea').value.trimEnd();
      document.querySelector('#bestRestaurant p').textContent = '';
      document.querySelector('#workers p').textContent = '';
      const restaurants = input.split('","').reduce((acc, curr, i, arr) => {
         let restaurant = ''
         let names = '';
         if (!i) {
            curr = curr.slice(2);
         }
         if (i === arr.length - 1) {
            curr = curr.slice(0, curr.length - 2);
         }
         curr.split(', ').forEach((x, y) => {

            if (y) {
               let infoEmployee = x.split(' ');
               let name = infoEmployee[0];
               let salary = Number(infoEmployee[1]);
               acc[restaurant][name] = salary;

            } else {
               names = x.split(' - ');
               restaurant = names[0];
               let infoEmployee = names[1].split(' ');
               let name = infoEmployee[0];
               let salary = Number(infoEmployee[1]);
               if (!acc.hasOwnProperty(restaurant)) {
                  acc[restaurant] = {};
               }
               acc[restaurant][name] = salary;
            }
         });
         return acc;
      }, {})

      let arrRestaurants = Object.entries(restaurants);
      let bestRestaurant = '';
      let averageBestSalary = 0;

      for (const restaurant of arrRestaurants) {
         let salaries = Object.values(restaurant[1]);
         let currAverageSalary = 0;
         for (const salary of salaries) {
            currAverageSalary += salary
         }
         currAverageSalary = Number((currAverageSalary / salaries.length).toFixed(2));
         if (currAverageSalary > averageBestSalary) {
            averageBestSalary = currAverageSalary;
            bestRestaurant = restaurant[0];
         }
      }

      let bestSalary = Object.values(Object.values(restaurants[bestRestaurant])).sort((a, b) => b - a)[0].toFixed(2);
      let bestRestaurantMessage = `Name: ${bestRestaurant} Average Salary: ${averageBestSalary.toFixed(2)} Best Salary: ${bestSalary}`;
      document.querySelector('#bestRestaurant p').textContent = bestRestaurantMessage;

      let employers = [];
      for (const employee of Object.entries(restaurants[bestRestaurant]).sort((a, b) => b[1] - a[1])) {
         employers.push(`Name: ${employee[0]} With Salary: ${employee[1]}`);
      }

      let bestRestaurantEmployers = employers.join(' ');
      document.querySelector('#workers p').textContent = bestRestaurantEmployers;
   }
}