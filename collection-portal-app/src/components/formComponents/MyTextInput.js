import { useField } from "formik";

const MyTextInput = ({ label, ...props }) => {
  const [field, meta] = useField(props);
  return (
    <div className="d-flex flex-column justify-content-center align-items-center">
      <label className="m-3 fs-3" htmlFor={props.name}>{label}</label>
      <input id={props.name} {...props} {...field} />
      {meta.touched && meta.error ? (
        <div className="error">{meta.error}</div>
      ) : null}
    </div>
  )
}

export default MyTextInput