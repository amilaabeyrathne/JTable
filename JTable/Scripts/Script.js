$(document).ready(function () {
    $('#MarksTable').jtable({
        title: 'Marks Detail',
        actions: {
            listAction: '/Home/GetStudentMarks',
            createAction: '/Home/Create',
            updateAction: '/Home/Edit',
            deleteAction: '/Home/Delete'
        },
        fields: {
            ID: {
                key: true,
                list: false
            },
            RollNumber: {
                title: 'Roll Number',
                width: '15%'
            },
            Name: {
                title: 'Student Name',
                width: '45%'
            },
            MarksObtained: {
                title: 'Marks Obtained',
                width: '15%',
            },
            TotalMarks: {
                title: 'Total Marks',
                width: '15%',
            }
        }
    });
    $('#MarksTable').jtable('reload');
});