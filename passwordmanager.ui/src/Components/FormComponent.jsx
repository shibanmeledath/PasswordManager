
// eslint-disable-next-line react/prop-types
function FormComponent({ title, onSubmit, children }) {
    return (
        <>
            <h1>{title}</h1>
            <form method="post" onSubmit={onSubmit}>

                {children} 

            </form>
        </>
    );
}




export default FormComponent;