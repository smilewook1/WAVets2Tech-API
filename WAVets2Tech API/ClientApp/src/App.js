import React, { useState, useEffect } from 'react';

const App = () => {

    const [students, setStudents] = useState([]);

    useEffect(() => {
        fetch("api/student")
            .then((response) => {
                return response.json();
            })
            .then(data => {
                setStudents(data);  
                })
            }, []);


    return (<main>
        {
            (students != null) ?
                students.map((index, id) => (
                    <h3 key={id}>
                        Id: {index.internalId}, Email: {index.email}, First Name: {index.firstName}, Last Name: {index.lastName}, Password: {index.passwordHash}
                    </h3>
                ))
                :
                <div>Loading</div>
        }
    </main>
    )
}

export default App;
