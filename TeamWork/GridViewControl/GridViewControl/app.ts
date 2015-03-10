
var schoolsGrid = controls.getGridView("#grid-view-holder",4);
schoolsGrid.addHeader("Name", "Location", "Total Students", "Specialty");
schoolsGrid.addRow("PMG", "Burgas", 400, "Math");
schoolsGrid.addRow("TUES", "Sofia", 500, "IT");
schoolsGrid.addRow("Telerik Academy", "Sofia", 5000, "IT");
schoolsGrid.render();

