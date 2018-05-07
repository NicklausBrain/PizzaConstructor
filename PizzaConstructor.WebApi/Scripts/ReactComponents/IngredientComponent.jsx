class IngredientComponent extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="imageTabContent">
                <h5>{this.props.Name}</h5>
                <img
                    className="ingredientImage"
                    src={this.props.ImageUrlMain}
                    data-id={this.props.Name}
                    draggable="true"
                    onDragStart={this.dragStart.bind(this)}
                    id={this.props.Name}
                />
                <p>Price: {this.props.Price} $</p>
            </div>
        );
    }

    // handler to dragstart event
    dragStart(ev) {
        ev.dataTransfer.setData("text", ev.target.id);
    }
}