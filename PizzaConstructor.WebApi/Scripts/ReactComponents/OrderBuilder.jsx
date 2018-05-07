class OrderBuilder extends React.Component {

    constructor() {
        super();

        this.state = {
            pizza: {},
            contacts: {},
            prevStat: "",
            isAuth: false
        };
    }

    componentWillMount() {
        this.isAuthenticated();
    }

    render() {
        if (this.props.action === 'templates') {
            return (
                <div>
                    <TemplateBox
                        myAlertTop={this.myAlertTop.bind(this)}
                        savePizza={this.savePizza.bind(this)}
                        makeOrder={this.makeOrder.bind(this)}
                        isAuth={this.state.isAuth}
                    />
                    <div className="container">
                        <ModaleBox
                            makeOrder={this.makeOrder.bind(this)}
                            alertShow={this.myAlertTop.bind(this)}
                        />
                    </div>
                </div>
            );
        } else {
            return (
                <div>
                    <PizzaConstructorComponent
                        savePizza={this.savePizza.bind(this)}
                        myAlertTop={this.myAlertTop.bind(this)}
                        makeOrder={this.makeOrder.bind(this)}
                    />
                    <div className="container">
                        <ModaleBox
                            makeOrder={this.makeOrder.bind(this)}
                            alertShow={this.myAlertTop.bind(this)}
                        />
                    </div>
                </div>
            );
        }

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

    savePizza(tempalteDto) {
        this.setState({ pizza: tempalteDto });
    }

    makeOrder(contact) {

        var newOreder = {
            "IsTemplate": true,
            "Pizza": this.state.pizza,
            "Contact": contact
        };
        console.log(newOreder);

        $.ajax({
            method: 'POST',
            url: '../api/orders',
            data: newOreder,
            success: function () {
                location.href = "../?message=1&&isDanger=false";
            }
        });
    }

    isAuthenticated() {
        $.ajax({
            method: 'GET',
            url: '../api/authentication',
            success: (data) => {
                this.setState({isAuth: data });
            }
        });
    }
}