class OrdersHistory extends React.Component {

    constructor() {
        super();        
        this.state = {
            pizzaItems: [],
            pizza: {}
        };
    }

    componentWillMount() {
        this.fetchPizzaItems();
    }

    render() {
        return (
            <div className="row template-box container">
                {this.getPizzaItems()}
            </div>
        );
    }

    fetchPizzaItems() {
        $.ajax({
            method: 'GET',
            url: '../api/ordershistory',
            success: (pizzaItems) => {
                this.setState({ pizzaItems });
            }
        });
    }

    getPizzaItems() {

        return this.state.pizzaItems.map((pizza) => {
            return (<PizzaItem
                        name={pizza.Name}
                        imageUrl={pizza.ImageUrl}
                        price={pizza.TotalCost} //Add Date to PizzaItemDTO ???
                        date={pizza.Date.slice(0, 10)}
                        ingredients={pizza.Ingredients}                        
                    />);
        });
    }    
}



