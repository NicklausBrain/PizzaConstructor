class AdminBox extends React.Component {

    constructor() {
        super();

        this.state = {
            orders: [],
            newOrders:0,
            prevStat: ""
        };
    }

    componentWillMount() {
        this.fetchOrders(0, 15);
    }

    render() {
        return (
            <div>
                <div className="myAlert-top alert col-md-6 col-md-offset-3 col-sm-6 col-sm-offset-2">
                    <a href="#" className="close" data-dismiss="alert" aria-label="close"></a>
                    <strong></strong>
                </div>
                <div className="admin-box row">
                    <div className="col-md-10 col-md-offset-1">
                        {this.getOrders()}
                    </div>
                </div>
                <div className="row center load-more">
                    <div className="col-md-2 col-md-offset-5">
                        <button className="btn green" onClick={this.loadMore.bind(this)}>Load more</button>
                    </div>
                </div>
            </div>

        );
    }

    fetchOrders(index, num) {
        $.ajax({
            method: 'GET',
            url: '../api/orders?index=' + index + '&&num=' + num,
            success: (orders) => {
                allOrders = this.state.orders.concat(orders);
                console.log(allOrders);
                this.setState({ newOrders: orders.length });
                this.setState({ orders:allOrders });
            }
        });
    }

    getOrders() {
        return this.state.orders.map((order) => {
            return (<AdminBoxOrder
                order={order}
                changeOrderStatus={this.changeOrderStatus.bind(this)}
            />);
        });
    }

    changeOrderStatus(newOrder) {
        $.ajax({
            type: 'PUT',
            url: '../api/orders',
            data: newOrder,
            success: this.myAlertTop("Status was changed!","alert-success")
        });
    }

    myAlertTop(text, status) {

        $(".myAlert-top").toggleClass(this.state.prevStat, false);
        $(".myAlert-top").toggleClass(status, true);
        this.setState({ prevStat: status });


        $(".myAlert-top strong").html(text);
        $(".myAlert-top").fadeIn();
        setTimeout(function () {
            $(".myAlert-top").fadeOut();
        }, 2000);
    }

    loadMore() {
        if (this.state.newOrders < 15) {
            $('.load-more button').hide();
        } else {
            this.fetchOrders(this.state.orders.length, 15);
        }
    }
}