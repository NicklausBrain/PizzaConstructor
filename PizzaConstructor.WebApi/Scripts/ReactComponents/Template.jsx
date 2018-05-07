class Template extends React.Component {

    render() {
        return (
            <div className="center thumbnail template hovereffect" id="poi">
                <div>
                    <h2>{this.props.name}</h2>

                    <PizzaImageComponent
                        pizza={{
                            Ingredients: this.props.ingredients,
                            Name: this.props.name
                        }}
                        styleClassName="PizzaConstructorPreview"
                    />

                    <div className="overlay">
                        <p >
                            <a href="#" className="modal-caller" data-toggle="modal" data-target="#myModal"
                                onClick={this.renderToConstructor.bind(this)}>MAKE ORDER</a>
                        </p>
                    </div>

                    <p>Price: {this.props.price} $</p>
                </div>
            </div>
        );
    }

    componentDidMount() {
        if (!this.props.isAuth) {
            $('.modal-caller').attr("data-toggle", "");
        }
    }

    renderToConstructor() {
        event.preventDefault();

        if (this.props.isAuth) {
            var templateDto = {
                "Name": this.props.name,
                "TotalCost": this.props.price,
                "ImageUrl": this.props.imageUrl,
                "Ingredients": this.props.ingredients
            };
            this.props.savePizza(templateDto);
        } else {
            this.props.myAlertTop("Only authenticated user can make order", "alert-danger");
            return;
        }
    }
}