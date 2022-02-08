function solve(arr,criteria){
    let result =  [];
    class Ticket{
        constructor(destination,price,status){
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }
    arr.forEach(x => {
        let [destination,price,status] = x.split('|');
        const currentTicket = new Ticket(destination,price,status);
        result.push(currentTicket);
    });
    criteria == 'price' ? result.sort((a,b) => a[criteria]- b[criteria]) : result.sort((a,b) => a[criteria].localeCompare(b[criteria]));

    return result;
}
console.log(solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
));