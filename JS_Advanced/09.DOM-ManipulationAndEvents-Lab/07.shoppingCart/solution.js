function solve() {
   let addButtons = Array.from(document.querySelectorAll('.product .add-product'));
   let showBox = document.querySelector('.shopping-cart textarea');
   addButtons.forEach(x => {
      x.addEventListener('click', addToShopingCart);
   });
   let sum = 0;
   let productsNames = new Set();
   let text = '';
   function addToShopingCart(ev){
      let product = ev.currentTarget.parentNode.parentNode.querySelector('.product-details .product-title').textContent;
      let price = Number(ev.currentTarget.parentNode.parentNode.querySelector('.product-line-price').textContent);
      
      productsNames.add(product);
      sum += price;
      text += `Added ${product} for ${price.toFixed(2)} to the cart.\n`
      showBox.textContent = text;
      
   }

   let checkoutBtn = document.querySelector('.checkout');
   checkoutBtn.addEventListener('click', (ev) => {
      Array.from(ev.currentTarget.parentNode.querySelectorAll('.add-product')).forEach(x => x.setAttribute('disabled',''));
      ev.currentTarget.setAttribute('disabled','')
      text += `You bought ${Array.from(productsNames).join(', ')} for ${sum.toFixed(2)}.`
      showBox.textContent = text;
   });
}