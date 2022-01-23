function solve() {
  let [...textToPtag] = document.querySelector('#input').value;
  textToPtag = textToPtag.map(x => escapeHtml(x)).join('').split('.').filter(x => x).filter(x => !/^\s*$/.test(x)).map(x => x + '. ');
  document.querySelector('#output').innerHTML = '';
  while (textToPtag.length) {
    let current = textToPtag.splice(0, 3).join('').trimEnd();
    document.querySelector('#output').innerHTML += `<p>${current}</p>`;
  }

  function escapeHtml(value) {
    return value
      .toString()
      .replace(/&/g, '&amp;')
      .replace(/</g, '&lt;')
      .replace(/>/g, '&gt;')
      .replace(/"/g, '&quot;')
      .replace(/'/g, '&#39;');
  }
}
