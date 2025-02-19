import { useState } from "react";
import FormComponent from "./FormComponent";
import InputComponent from "./InputComponent";
import { useParams, useNavigate } from "react-router-dom";
import { useEffect } from "react";
import api from "../../Api/Api"
import ButtonComponent from "./ButtonComponent";
function EditPasswordComponent() {
    const { id } = useParams();
    const [formData, setFormData] = useState({
        name: '',
        username: '',
        email: '',
        phone:'',
        password:''
    });
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const navigate = useNavigate();
    useEffect(() => {
        const fetchpassword = async () => {
            try {
                const response = await api.get(`/${id}`);
                setFormData(response.data);
            } catch (e) {
                console.log(e);
                setError("Error in fetching data")
            }
            finally {
                setLoading(false)
            }
        };
        fetchpassword();
    }, [id])
    const onChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        });
    };
    const handleSubmit = async (e) => {
        e.preventDefault();
        setError(null);

        try {
            const response = await api.put(`/${id}`, formData);
            console.log(response.data);
            navigate('/view')
        } catch (e) {
            console.log(e)
            setError("Error in editting")
        }

    };

    if (loading) {
        return <div>Loading........</div>;
    }

    return (
        <>
           
            <FormComponent title="Edit Password" onSubmit={handleSubmit}>
                {error && <div>{error}</div>}
                <InputComponent label="Name" name="name" type="text" value={formData.name} onChange={onChange}  />
                <InputComponent label="Username" name="username" type="text" value={formData.username} onChange={onChange} />
                <InputComponent label="Email" name="email" type="email" value={formData.email} onChange={onChange} />
                <InputComponent label="Phone" name="phone" type="number" value={formData.phone} onChange={onChange} />
                <InputComponent label="Password" name="password" type="password" value={formData.password} onChange={onChange} />
                <ButtonComponent name="Save" type="submit" />
            </FormComponent>

        </>
    );
};
export default EditPasswordComponent;