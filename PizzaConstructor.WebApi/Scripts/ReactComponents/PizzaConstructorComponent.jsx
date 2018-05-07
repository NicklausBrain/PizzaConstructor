class PizzaConstructorComponent extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            pizzaIngredients: [],
            totalCost: 0,
            name: "",
            categoryIngredients: []
        }

        this._loadCategoryIngredients();
    }

    render() {        
        return (
            <div className="pizza-constructor section">

                <div className="row container center">
                    <h4>Pizza constructor</h4>
                </div>

                <div className="row row-eq-height">

                    <div className="col-md-3 " id="pizza-ingr-list">
                        <PizzaIngredientsComponent ingredients={this.state.pizzaIngredients} removeIngredient={this._removeIngredient.bind(this)} />
                    </div>

                    <div className="col-md-6">
                        <PizzaImageComponent
                            pizza={{
                                Ingredients: this.state.pizzaIngredients
                            }}
                            allowDropIngredient={this.allowDrop.bind(this)}
                            dropIngredient={this.dropIngredient.bind(this)}
                            styleClassName="PizzaConstructorFull"
                        />
                    </div>

                    <div className="col-md-3" id="pizza-ingr">
                        <TabComponent categoryIngredients={this.state.categoryIngredients} />
                    </div>

                </div>

                <div className="row">

                    <div className="col-md-4 col-md-offset-4 pizza-name col-sm-4 col-sm-offset-4">
                        <PizzaTitleComponent isConstructor={true} totalCost={this.state.totalCost} changeName={this.changeName.bind(this)} />
                    </div>

                    <div className="col-md-2 col-md-offset-5 my-button col-sm-2 col-sm-offset-5">
                        <button
                            onClick={this.savePizza.bind(this)}
                            data-toggle=""
                            data-target="#myModal"
                            className="btn-info btn-large col-md-12"
                            id="modal-caller"
                        >Save</button>
                    </div>

                </div>
            </div>
        );
    }

    // Callback on drop ingredient event
    dropIngredient(ev) {

        ev.preventDefault();
        var data = ev.dataTransfer.getData("text");
        var ingredientElement = document.getElementById(data);
        var ingredientName = ingredientElement.getAttribute("data-id");

        this._getIngredient(ingredientName);

        //this._getIngredientFromServer(ingredientElement.getAttribute("data-id"));
    }

    // Callback to allow drop ingredient
    allowDrop(ev) {
        ev.preventDefault();
    }

    // Find ingredient by name in "storage"
    _getIngredient(ingredientName) {
        var ingredient = null;

        for (var i = 0; i < this.state.categoryIngredients.length; i++) {
            var ingredients = this.state.categoryIngredients[i].Ingredients;
            for (var j = 0; j < ingredients.length; j++) {
                if (ingredients[j].Name === ingredientName) {
                    ingredient = ingredients[j];
                    break;
                }
            }
            if (ingredient !== null) {
                break;
            }
        }

        if (ingredient !== null) {
            this._addIngredient(ingredient);
        }
    }

    // Add ingredient to pizza and update state
    _addIngredient(ingredientDto) {
        if (this._findIngredientByName(ingredientDto.Name) === -1) {
            var currentIngredients = this.state.pizzaIngredients;
            currentIngredients.push(ingredientDto);
            var newPrice = this.state.totalCost + ingredientDto.Price;
            this.setState({
                pizzaIngredients: currentIngredients,
                totalCost: newPrice
            });
        }
    }

    // Remove ingredient from pizza and update state
    _removeIngredient(ingredientName) {

        var indexRemove = this._findIngredientByName(ingredientName);
        console.log(indexRemove);
        if (indexRemove !== -1) {
            var currentIngredients = this.state.pizzaIngredients;
            var newPrice = this.state.totalCost - currentIngredients[indexRemove].Price;
            currentIngredients.splice(indexRemove, 1);
            this.setState({
                pizzaIngredients: currentIngredients,
                totalCost: newPrice
            });
        }
    }

    // Find index of pizza ingredient by name
    _findIngredientByName(ingredientName) {
        var currentIngredients = this.state.pizzaIngredients;
        var index = -1;
        for (var i = 0; i < currentIngredients.length; i++) {
            if (currentIngredients[i].Name === ingredientName) {
                index = i;
                break;
            }
        }
        return index;
    }    

    // Send created pizza to the parent component
    savePizza(e) {
        if ($("#pizza-name").val() == "") {
            $("#pizza-name").attr("style", "border:1px solid red");
            return;
        } else {
            $("#pizza-name").attr("style", "");
            $('#myModal').modal('show');
        }

        var pizza = {
            "Name": this.state.name,
            "TotalCost": this.state.totalCost,
            "Ingredients": this.state.pizzaIngredients
        };

        this.props.savePizza(pizza);
    }

    changeName(name) {
        this.setState({ name: name });
    }


    // Function to connect server and load all ingredients
    _loadCategoryIngredients() {        

        $.ajax({
            type: "GET",
            url: "/api/categoryingredients",
            success: (categoryIngredients) => {
                this._initCategoryIngredients(categoryIngredients);
            }
        });
    }

    // Callback function 
    _initCategoryIngredients(categoryIngredients) {
        
        this.setState({
            categoryIngredients: categoryIngredients
        });
    }

    // Send request to server and add ingredient to pizza
    //_getIngredientFromServer(ingredientName) {
    //    $.ajax({
    //        type: "GET",
    //        url: "/api/ingredient",
    //        data: {
    //            ingredientName: ingredientName
    //        },
    //        success: (ingredientDto) => {
    //            this._addIngredient(ingredientDto);
    //        }
    //    });
    //}
}
