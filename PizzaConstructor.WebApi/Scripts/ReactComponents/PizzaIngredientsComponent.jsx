class PizzaIngredientsComponent extends React.Component {

    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div id="ingr-list-content">
                <h5>Pizza ingridients:</h5>
                <div >
                    {
                        this.props.ingredients.map((i, j) => {
                            return (
                                <div key={j} className="ingrid-item">
                                    <p>- {i.Name} {i.Price}$
                                <i className="fa fa-times pointer" auto-hidden="true" data-id={i.Name} onClick={this.removeIngredient.bind(this)}></i>
                                    </p>
                                </div>);
                        })
                    }
                </div>
            </div>
        );
    }

    // Handler to remove ingredient click
    removeIngredient(e) {
        e.preventDefault();
        var removeName = e.target.getAttribute("data-id");
        this.props.removeIngredient(removeName);
    }
}