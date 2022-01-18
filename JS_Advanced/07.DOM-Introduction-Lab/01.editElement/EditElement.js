    function editElement(refrnce, elToReplace, elToInsert) {
        while (refrnce.innerHTML.includes(elToReplace)) {
            refrnce.innerHTML = refrnce.innerHTML.replace(elToReplace, elToInsert);
        }
    }