import { useField } from "formik";

const MyNumberInput = ({ label, ...props }) => {
  const [field, meta] = useField(props);
  return (
    <div className="d-flex flex-column justify-content-center align-items-center form-group">
      <label className="m-2 fs-4" htmlFor={props.name}>{label}</label>
      <input className="form-control" id={props.name} {...props} {...field} type="number"/>
      {meta.touched && meta.error ? (
        <div className="text-danger">{meta.error}</div>
      ) : null}
    </div>
  )
}

export default MyNumberInput