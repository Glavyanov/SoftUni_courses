function factory(library,orders){
    let result = [];
    for (const order of orders) {
        let current = {};
        Object.keys(order).forEach((key,i) =>{
            if (i == 0) {
                current = Object.assign({}, order[key]); 
            }else{
                order[key].map(x => {
                    current[x] = library[x];
                });
            }
        });
        result.push(Object.assign({},current));
    }
    
    return result;
}
const library = {
    print: function () {
      console.log(`${this.name} is printing a page`);
    },
    scan: function () {
      console.log(`${this.name} is scanning a document`);
    },
    play: function (artist, track) {
      console.log(`${this.name} is playing '${track}' by ${artist}`);
    },
  };
  const orders = [
    {
      template: { name: 'ACME Printer'},
      parts: ['print']      
    },
    {
      template: { name: 'Initech Scanner'},
      parts: ['scan']      
    },
    {
      template: { name: 'ComTron Copier'},
      parts: ['scan', 'print']      
    },
    {
      template: { name: 'BoomBox Stereo'},
      parts: ['play']      
    }
  ];
  const products = factory(library, orders);
  console.log(products);
  
  