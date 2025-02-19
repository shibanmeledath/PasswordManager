import { useEffect, useState } from "react";
import api from "../../Api/Api";
import ButtonComponent from "./ButtonComponent";
import { useNavigate } from "react-router-dom"
function ViewPasswordsComponent()
{
    const [passwords, setPasswords] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    const navigate = useNavigate();

    useEffect(() => {
        const fetchPassword = async () => {
            try {
                const response = await api.get('/');
                setPasswords(response.data);
            } catch (e) {
                setError("Error i Fetching data");
                console.log(e)
            }
            finally {
                setLoading(false)
            }
        };
        fetchPassword();
    }, []);
    const handleEdit = (id) => {
        navigate(`/edit-password/${id}`);

    };
    const handleDelete = async (id) => {
        const confirm = window.confirm("Are you sure");
        if (!confirm) {
            return;
        }

        try {
            await api.delete(`/${id}`);
            setPasswords(passwords.filter((password) => password.id !== id));
        } catch (e) {
            console.log(e)
            setError("Failed to delete")
        }

    };
    
    if (error) {
        return <div>{error}</div>;
    }
    if (loading) {
        return <div>Loading.............. </div>;
    }

    return (
        <>
            <div>
                
            
                <h2>View Password</h2>
                {passwords.length > 0 ? (
                    <table>
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Username</th>
                                <th>Email</th>
                                <th>Phone</th>
                                <th>Password</th>
                                <th>Edit</th>
                                <th>Delete</th>
                            </tr>

                        </thead>
                        <tbody>
                            {passwords.map((password) => (
                                <tr key={password.id}>
                                    <td>{password.name}</td>
                                    <td>{password.username}</td>
                                    <td>{password.email}</td>
                                    <td>{password.phone}</td>
                                    <td>{password.password}</td>
                                    <td>
                                        <ButtonComponent type="button" name="Edit" onClick={()=>handleEdit(password.id) }  />

                                    </td>
                                    <td>
                                        <ButtonComponent type="button" name="Delete" onClick={() => handleDelete(password.id)} />
                                    </td>
                                </tr>
                            ))}
                        
                        </tbody>
                    </table>

                ): (
                        <div>passwords not found</div>
                    )}


            </div>
        
        </>
    );
}
export default ViewPasswordsComponent;