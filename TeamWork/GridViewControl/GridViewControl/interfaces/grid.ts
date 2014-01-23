module controls {
    
    export interface IGridItem {

        Values: any[];
    }

    export interface IGridView {

        addHeader(...values);
        addRow(...values);
        render();
    }

} 