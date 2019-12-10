var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Unit = /** @class */ (function () {
    function Unit(stringJSON) {
        this.ListUnit = JSON.parse(stringJSON);
        console.log(this.ListUnit);
    }
    Unit.prototype.getListUnit = function () {
        return "Hello, " + this.ListUnit[0].Text;
    };
    return Unit;
}());
var rowTS = /** @class */ (function (_super) {
    __extends(rowTS, _super);
    function rowTS() {
        var _this = _super.call(this) || this;
        console.log("from here");
        return _this;
    }
    rowTS.prototype.RowWithRemoveButton = function () {
        this.No.textContent = "Hell Yeah!";
    };
    rowTS.prototype.print = function () {
        console.log("Hello! world");
    };
    return rowTS;
}(HTMLTableRowElement));
customElements.define("my-element", rowTS);
var tableTS = /** @class */ (function () {
    function tableTS(table, JSONString) {
        this.rowCount = 1;
        this.table = table;
        this.ListUnit = new Unit(JSONString);
    }
    tableTS.prototype.AddRow = function (index) {
        var newRow = document.createElement('my-element');
        var x = this.table.appendChild(newRow);
    };
    tableTS.prototype.RemoveRow = function (index) {
    };
    tableTS.prototype.addElement = function () {
        this.lblNo.textContent = (this.table.rows.length - 1).toString();
        this.slxUnit.appendChild(this.setHtmlSelectElement());
        this.txtPrice.appendChild(this.setHtmlInputElement());
        this.btnAdd.appendChild(this.setBtnAddElement());
    };
    tableTS.prototype.setBtnAddElement = function () {
        var _this = this;
        var btn = document.createElement('button');
        btn.textContent = "add";
        btn.className = "btn btn-flat btn-primary";
        btn.type = "button";
        btn.addEventListener('click', function () { _this.AddRow(0); });
        return btn;
    };
    tableTS.prototype.setHtmlInputElement = function () {
        var input = document.createElement('input');
        input.className = "form-control";
        return input;
    };
    tableTS.prototype.setHtmlSelectElement = function () {
        var Select = document.createElement('select');
        var Option = document.createElement('option');
        Object.keys(this.ListUnit.ListUnit).forEach(function (item) {
            console.log(item);
        });
        Select.className = "form-control select2";
        return Select;
    };
    tableTS.prototype.setHtmlOptionElement = function () {
        var opt1 = document.createElement("option");
        opt1.text = "OK";
        opt1.value = "1";
        return opt1;
    };
    return tableTS;
}());
var myBtn = /** @class */ (function (_super) {
    __extends(myBtn, _super);
    function myBtn() {
        var _this = _super.call(this) || this;
        _this.addEventListener('click', function () { alert("OK"); });
        return _this;
    }
    return myBtn;
}(HTMLButtonElement));
customElements.define("btn-test", myBtn, { extends: 'button' });
//# sourceMappingURL=Product.js.map