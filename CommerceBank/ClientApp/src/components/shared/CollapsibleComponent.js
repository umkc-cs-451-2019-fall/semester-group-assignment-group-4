import React, { Component } from 'react';
import './../styles/CollapsibleComponent.css';
export class CollapsibleComponent extends Component {
    constructor(props) {
        super(props)
    }

    componentDidMount() { }

    expandOrCollapse() {
        var collapsibleDiv = document.getElementById("hiddenDiv");
        var arrowIcon = document.getElementById("expandOrCollapseIcon");
        //Collapse
        if (collapsibleDiv.style.display === "block") {
            arrowIcon.className = "right";
            collapsibleDiv.style.display = "none";
            
        }
        else {
            //Expande
            arrowIcon.className = "down";
            collapsibleDiv.style.display = "block";
           
        }
    }
    render() {
        return (
            <div id="CollapsibleComponent">
                <button type="button" class="collapsible" onClick={this.expandOrCollapse}>{this.props.header}<i class="right" id="expandOrCollapseIcon"></i></button>
                <div class="content" id="hiddenDiv">
                    {this.props.content}
                </div>
            </div>
        );
    }
}