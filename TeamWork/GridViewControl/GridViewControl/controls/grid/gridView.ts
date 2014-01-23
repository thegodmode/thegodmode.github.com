/// <reference path="../../enums/grid.ts" />
module controls {
    class GridView implements IGridView {

        private __parent: HTMLElement;
        private __header: IGridItem;
        private __rows: IGridItem[];
        private __tableWidth: number;

        constructor(tableParentId: string, public tableWidth: number) {

            this.__parent = document.getElementById(tableParentId);
            this.__tableWidth = tableWidth;
            this.__rows = [];
        }

        addHeader(...values) {

            if (values.length != this.__tableWidth) {

                throw "Invalid Header. It must have the same length as gridview";
            }


            this.__header = createGridItem(values);


        }

        addRow(...values) {

            if (values.length != this.__tableWidth) {

                throw "Invalid Row. It must have the same length as gridview";
            }

            this.__rows.push(createGridItem(values));
        }

        render() {


            var table = document.createElement("table");
            table.appendChild(this.createRow(RowType.header, this.__header.Values));
            this.__rows.forEach((element) => {

                table.appendChild(this.createRow(RowType.row, element.Values));

            });

            if (this.__parent.hasChildNodes) {
                while (this.__parent.firstChild) {
                    this.__parent.removeChild(this.__parent.firstChild);
                }
            }

            this.__parent.appendChild(table);

        }

        createRow(rowType: number, values: any[]): HTMLElement {
            var parent = null;

            if (rowType == RowType.header) {
                parent = document.createElement("th");
            }
            else if (rowType == RowType.row) {
                parent = document.createElement("tr");
            }

            values.forEach((element) => {

                var td = document.createElement("td");
                td.textContent = element;
                parent.appendChild(td);
            });

            return parent;
        }
    }

    export function getGridView(tableParentId: string, tableWidth: number): IGridView {

        return new GridView(tableParentId, tableWidth);
    }
}