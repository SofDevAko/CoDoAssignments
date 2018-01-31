var students = [
{first_name: 'Michael', last_name: 'Jordan'},
{first_name: 'John', last_name: 'Rosales'},
{first_name: 'Mark', last_name: 'Guillen'},
{first_name: 'KB', last_name: 'Tonel'}
];

function studentsAndInstructors(array){
    for (i = 0; i < array.length; i++){
        console.log(array[i].first_name, array[i].last_name);
    }
}