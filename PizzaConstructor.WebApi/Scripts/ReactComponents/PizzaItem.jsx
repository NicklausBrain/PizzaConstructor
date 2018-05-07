class PizzaItem extends React.Component {
    render() {
        return (
            <div className="center thumbnail template hovereffect">
                <h2>{this.props.name}</h2>
                <PizzaImageComponent
                    pizza={{
                        Ingredients: this.props.ingredients
                    }}                    
                    styleClassName="PizzaConstructorPreview"
                />
                <p>{this.props.date}</p>
                <p>Price: {this.props.price} $</p>
            </div>
        );
    }
}


