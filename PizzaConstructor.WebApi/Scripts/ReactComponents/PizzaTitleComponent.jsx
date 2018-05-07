class PizzaTitleComponent extends React.Component {
    constructor(props) {
        super(props);

    }

    render() {
        if (this.props.isConstructor === true) {
            return ( 
                <div>
                    <p>Name your pizza: </p>
                    <input className="input-field" id="pizza-name" type="text" onChange={this.changeName.bind(this)} placeholder="Pizza name"/>
                    <br />
                    <p>Total price: {this.props.totalCost} $</p>
                </div>                
                );
        } else {
            return (
                <div>
                    <label>Название пиццы: {this.props.name}</label>
                    <br />
                    <label>Цена пиццы: {this.props.totalCost}</label>
                </div>
                );
        }
    }

    changeName(ev) {
        this.props.changeName(ev.target.value);
    }

}