class Textbox {
    constructor(selector,invalidSymbRegex){
        this._elements = document.querySelectorAll(selector);
        this._invalidSymbols = invalidSymbRegex;
        Array.from(this._elements)
        .forEach(el => el.addEventListener('change', () => this.value = el.value));
    }
    get elements(){
        return this._elements;
    }

    get value(){
        return this.elements[0].value;
    }

    set value(val){
        Array.from(this._elements).forEach(el => el.value = val);
    }

    isValid(){
        return !this._invalidSymbols.test(this.value);
    }
}

let textbox = new Textbox(".textbox",/[^a-zA-Z0-9]/);
let inputs = document.getElementsByClassName('textbox');

Array.from(inputs).forEach(el => el.addEventListener('click',function(){console.log(textbox.value);}));
