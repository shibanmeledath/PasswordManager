import { useNavigate } from 'react-router-dom'; 
import ButtonComponent from "./ButtonComponent";

function HomeComponent() {
    const navigate = useNavigate(); 


    const handleAddClick = () => {
        navigate('/add'); 
    };

    const handleViewClick = () => {
        navigate('/view'); 
    };

    return (
      
        <>
            <div className="container">

                <main>
                    <ButtonComponent
                        name="Add"
                        type="button"
                        onClick={handleAddClick}
                    />

                    <ButtonComponent
                        name="View"
                        type="button"
                        onClick={handleViewClick}
                    />

                </main> 

            </div>
         
          
        </>
    );
}

export default HomeComponent;