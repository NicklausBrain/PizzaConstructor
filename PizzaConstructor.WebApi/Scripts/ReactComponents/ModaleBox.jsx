class ModaleBox extends React.Component {

    render() {
        return (
            <div id="">
                <div className="myAlert-top alert col-md-6 col-md-offset-1 col-sm-6 col-sm-offset-2">
                    <a href="#" className="close" data-dismiss="alert" aria-label="close"></a>
                    <strong></strong>
                </div>

                <div id="myModal" className="modal fade" role="dialog">
                    <div className="modal-dialog">
                        <div id="order-form" className="modal-content">
                            <div className="modal-header">
                                <button type="button" className="close large" data-dismiss="modal">&times;</button>
                                <h4 className="modal-title text-center">Input your contacts</h4>
                            </div>
                            <div className="modal-body">
                                <input type="text" placeholder="Name" ref={input => this.contactName = input} /><br />
                                <input type="tel" placeholder="Phone" ref={input => this.contactPhone = input} /><br />
                                <input type="text" placeholder="Address" ref={input => this.contactAddress = input} /><br />
                            </div>
                            <div className="modal-footer">
                                <button type="button black" className="btn btn-default" data-dismiss="modal" onClick={this.closeMe.bind(this)}>Make order</button>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        );
    }

    closeMe() {
        if (this.contactName.value == "" || this.contactPhone.value == "" || this.contactAddress.value == "") {
            this.props.alertShow("Input all reuired data!", "alert-danger");
            return;
        }

        if (!this.validatePhone(this.contactPhone.value)) {
            this.props.alertShow("Input valid telephone number!", "alert-danger");
            return;
        }

        var Contact = {
            "Name": this.contactName.value,
            "Phone": this.contactPhone.value,
            "DeliveryAddress": this.contactAddress.value
        };

        this.props.makeOrder(Contact);
    }

    validatePhone(phoneNumber) {
        var phoneNumberPattern = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/im;
        return phoneNumberPattern.test(phoneNumber);
    }
}