class Unit {
    ListUnit: JSON;
    rowCount: number;
    constructor(stringJSON: string) {
        this.ListUnit = JSON.parse(stringJSON);
        console.log(this.ListUnit);
    }
    
    getListUnit() {
        return "Hello, " + this.ListUnit[0].Text;
    }
}


class rowTS extends HTMLTableRowElement {
    No: HTMLTableCellElement;
    cboUnit: HTMLSelectElement;
    txtPrice: HTMLInputElement;
    btnAdd: HTMLButtonElement;
    btnRemove: HTMLButtonElement;

    constructor() {
        super();
        console.log("from here");
    }

    RowWithRemoveButton() {
        this.No.textContent = "Hell Yeah!";
    }

    print() {
        console.log("Hello! world");
    }
}

customElements.define("my-element", rowTS);

class tableTS {
    table: HTMLTableElement;
    ListUnit: Unit;
    rowCount: number = 1;
    isAdd: boolean;
    isRemove: boolean;
    stringNewRow: string;

    lblNo: HTMLTableCellElement;
    slxUnit: HTMLTableCellElement;
    txtPrice: HTMLTableCellElement;
    btnAdd: HTMLTableCellElement;
    btnRemove: HTMLTableCellElement;

    constructor(table: HTMLTableElement, JSONString: string) {
        this.table = table;
        this.ListUnit = new Unit(JSONString);
    }

    AddRow(index: number) {
        let newRow = document.createElement('my-element');
        let x = this.table.appendChild(newRow);
        
    }

    RemoveRow(index: number) {
        
    }

    addElement() {
        this.lblNo.textContent = (this.table.rows.length - 1).toString();
        this.slxUnit.appendChild(this.setHtmlSelectElement());
        this.txtPrice.appendChild(this.setHtmlInputElement());
        this.btnAdd.appendChild(this.setBtnAddElement());
    }

    setBtnAddElement() {
        var btn = document.createElement('button');
        btn.textContent = "add";
        btn.className = "btn btn-flat btn-primary";
        btn.type = "button";
        btn.addEventListener('click', () => { this.AddRow(0) });
        return btn;
    }

    setHtmlInputElement() {
        var input = document.createElement('input');
        input.className = "form-control";
        return input;
    }

    setHtmlSelectElement() {
        var Select = document.createElement('select');
        var Option = document.createElement('option');

        Object.keys(this.ListUnit.ListUnit).forEach(function (item) {
            console.log(item);
        })
 
        Select.className = "form-control select2";
        return Select;
    }

    setHtmlOptionElement() {
        var opt1 = document.createElement("option");
        opt1.text = "OK";
        opt1.value = "1";
        return opt1;
    }
}


class myBtn extends HTMLButtonElement {
    constructor() {
        super();
        this.addEventListener('click', () => { alert("OK") });
    }

}

customElements.define("btn-test", myBtn, { extends: 'button' });