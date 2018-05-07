class TabContentComponent extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        if (this.props.selectedIndex == this.props.currentIndex) {
            return (<div className="tabcontent center" style={{display: 'block'}}>
                {
                    this.props.ingredients.map((ingr, i) => {
                        return <IngredientComponent
                            key={i}
                            ImageUrlMain={ingr.ImageUrlMain}
                            Name={ingr.Name}
                            Price={ingr.Price}
                        />
                    })
                }
            </div>);
        } else {
            return (<div className="tabcontent" style={{ display: 'none' }}>
                {
                    this.props.ingredients.map((ingr, i) => {
                        return <IngredientComponent
                            key={i}
                            ImageUrlMain={ingr.ImageUrlMain}
                            Name={ingr.Name}
                            Price={ingr.Price}
                        />
                    })
                }
            </div>);
        } 
    }

    
}