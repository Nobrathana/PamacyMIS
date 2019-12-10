

class TblUnitOfProduct extends React.Component {
    constructor(props){
        super(props);
        
        //Fields or Properties
        this.state = {
            isShow: true,
        };

        this.currentRow = {
            UNIT: null,
            PRICE: 0 
        }

        this.tableData = [];
        this.rowCount = 1;
        this.price = 0;

        this.HandleAddRow = this.HandleAddRow.bind(this);
        this.HandleRemmoveRow = this.HandleRemmoveRow.bind(this);
        this.IncreaseRowCount = this.IncreaseRowCount.bind(this);
    }

    HandleAddRow(events) {
        alert(this.price)   
    }

    HandleRemmoveRow(events){

    }

    IncreaseRowCount(){
        this.rowCount++;
    }

    getPrice(e){
        
    }


    render() {
        
        return (
          <div className="tblUnit">
             <table className="table">
                 <thead>
                     <tr>
                     <th>No.</th>
                     <th>Unit</th>
                     <th></th>
                     <th>Price</th>
                     <th></th>
                     <th></th>
                     </tr>
                 </thead>
                 <tbody>
                     <tr>
                     <td>{this.rowCount}</td>
                     <td>
                         <select className="form-control select2">
                             <option>A</option>
                             <option>B</option>
                         </select>
                     </td>
                     <td> x 1 </td>
                     <td>
                         <input type="text" className="form-control" onChange={this.getPrice} />
                     </td>
                     <td>
                         <button type="button" className="btn btn-flat" onClick={this.HandleAddRow}>a</button>
                     </td>
                     <td>
                          <button type="button" className="btn btn-flat" onClick={this.IncreaseRowCount}>Increase State</button>
                     </td>
                     </tr>
                 </tbody>
                    
             </table>
          </div>
    );
    }
}