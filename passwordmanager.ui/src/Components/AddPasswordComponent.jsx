import { useState } from "react";
import FormComponent from "./FormComponent";
import InputComponent from "./InputComponent"
import ButtonComponent from "./ButtonComponent";
import api from "../../Api/Api";

function AddPasswordComponent() {
    const [formData, setFormData] = useState({
        name: '',
        username: '',
        email: '',
        phone:'',
        password:''
    })
    const [error, setError] = useState(null);

    const onChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        });
    };
    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            var response = await api.post('/', formData);
            console.log("Sucess")
            console.log(response)
            setFormData({
                name: '',
                username: '',
                email: '',
                phone:'',
                password: ''
            })
        } catch (e) {
            setError("Error in postig data")
            console.log("Error")
            console.log(e)
        }


    };

   
    return (
        <>
            <FormComponent title="Add Password" onSubmit={handleSubmit}>
                {error && <div>{error}</div>}
                <InputComponent label="Name" name="name" type="text" value={formData.name} onChange={onChange} />
                <InputComponent label="Username" name="username" type="text" value={formData.username} onChange={onChange} />
                <InputComponent label="Email" name="email" type="email" value={formData.email} onChange={onChange} />
                <InputComponent label="Phone" name="phone" type="number" value={formData.phone} onChange={onChange} />
                <InputComponent label="Password" name="password" type="password" value={formData.password} onChange={onChange} />
                <ButtonComponent type="submit" name="Add" />

            </FormComponent>
        </>
    );
}

export default AddPasswordComponent;