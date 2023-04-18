import React, { useState, useEffect } from 'react';

const App = () => {

    const [students, setStudents] = useState([]);

    useEffect(() => {
        fetch("api/student/GetStudents")
            .then((response) => {
                return response.json();
            })
            .then(data => {
                setStudents(data);  
                })
            }, []);


    return (<main>
        {
            (students != null) ? students.map((index) => <h3>this is email: {index.email}
            </h3>) : <div>Loading</div>
        }

    </main>)
}

export default App;