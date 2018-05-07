class AdminBoxOrder extends React.Component {

    render() {
        return (
            <div className="order-item">
                <div className="thumbnail">
                    <div className="caption">
                        <h6>{this.props.order.User.Name}</h6>
                        <label>Tel: {this.props.order.Contact.Phone}</label>
                        <hr />
                        <div className="ingeds">
                            {
                                this.props.order.Pizzas[0].Ingredients.map((ingred) => {
                                    return (
                                        <p className="small">- {ingred.Name}</p>
                                    );
                                })
                            }
                        </div>
                        <hr />
                        <StatusBox
                            id={this.props.order.Id}
                            status={this.props.order.OrderStatus}
                        />
                        <div className="row">
                            <div className="col-xs-8" id="price-label">
                                Price: {this.props.order.TotalPrice} $
                            </div>
                            <button className="btn-success col-xs-4 center" onClick={this.changeOrderStatus.bind(this)}>Save</button>
                        </div>
                    </div>
                </div>
            </div>
        );
    }

    changeOrderStatus() {
        var newOrder = $.extend(true, {}, this.props.order);
        newOrder.OrderStatus.Status = $('*[data-id="' + this.props.order.Id + '"]').val();
        this.props.changeOrderStatus(newOrder);
    }
}

class StatusBox extends React.Component {
    render() {
        return (
            <div>
                <label>Status: </label>
                <select className="status-select" data-id={this.props.id}>
                    <option value="New">New</option>
                    <option value="Confirmed">Confirmed</option>
                    <option value="Cancelled">Cancelled</option>
                    <option value="Delivering">Delivering</option>
                    <option value="Completed">Completed</option>
                </select>
            </div>
        );
    }

    componentDidMount() {
        $('*[data-id="' + this.props.id + '"]').val(this.props.status.Status);
        console.log();
    }
}