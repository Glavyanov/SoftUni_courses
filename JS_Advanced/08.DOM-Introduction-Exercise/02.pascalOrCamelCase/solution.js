function solve() {
  let wordsToPerform = document.getElementById('text').value;
  let template = document.getElementById('naming-convention').value;
  let result = '';
  if (template === 'Camel Case') {
    result = wordsToPerform.split(' ').reduce((acc, el, i) => {
      i ? acc += el[0].toUpperCase() + el.substring(1).toLowerCase() : acc += el.toLowerCase();
      return acc;
    }, '');
  } else if (template === 'Pascal Case') {
    result = wordsToPerform.split(' ').reduce((acc, el) => {
      acc += el[0].toUpperCase() + el.substring(1).toLowerCase();
      return acc;
    }, '');
  } else {
    result = 'Error!';
  }
  document.getElementById('result').innerHTML = result;

}