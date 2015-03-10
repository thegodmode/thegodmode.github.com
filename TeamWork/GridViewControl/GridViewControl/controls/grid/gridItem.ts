module controls {
    
    class GridItem implements  IGridItem {
        private __gridItemValues: any[];

        constructor(values: any[]) {

            this.__gridItemValues = values;
        }

        get Values(): any[] {

            return this.__gridItemValues;
        }

    }

    export function createGridItem(values: any[]): IGridItem
    {
        var item = new GridItem(values);
        return item;
    }
    
} 