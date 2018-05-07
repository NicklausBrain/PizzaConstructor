class PizzaImageComponent extends React.Component {

    constructor(props) {
        super(props);
    }

    // Handler to allow drop ingredient
    dragOver(ev) {
        
        if (this.props.allowDropIngredient !== undefined) {
            this.props.allowDropIngredient(ev);
        } 
    }

    // Handler to drop ingredient
    drop(ev) {
        ev.preventDefault();

        if (this.props.dropIngredient !== undefined) {
            var data = ev.dataTransfer.getData("text");
            var ingredientElement = document.getElementById(data);
            this.props.dropIngredient(ev);
        }
    }

    render() {
        
        return (
            <div className={this.props.styleClassName} onDrop={this.drop.bind(this)} onDragOver={this.dragOver.bind(this)}>
            {
                    this.props.pizza.Ingredients.map((i, j) => {
                        return <img data-id={i.Name} src={i.ImageUrl} key={j} draggable="false" style={{ zIndex: i.Index }}/>
                    })
            }
            </div>        
        );
    }
}