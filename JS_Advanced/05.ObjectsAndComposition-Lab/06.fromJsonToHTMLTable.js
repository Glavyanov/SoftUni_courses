function solve(input){
    let students = JSON.parse(input);
   
    let html = '';
    html += '<table>' + '\n'+ '   ';
    html += `<tr>${Object.keys(students[0]).map(x => `<th>${escapeHtml(x).trim()}</th>`).join('')}</tr>`+'\n'+ '   ';
    students.forEach((element,i)=> {
        html += '<tr>';
        html += Object.values(element).map(x=> `<td>${escapeHtml(x)}</td>`).join('');
        if (i === students.length - 1) {
            html += '</tr>' +'\n';
        }else{
            html += '</tr>' + '\n'+ '   ';
        }
    });
    html += '</table>';
    console.log(html);
    
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