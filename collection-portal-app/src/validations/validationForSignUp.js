import * as Yup from 'yup'

export default Yup.object({
  email: Yup
    .string()
    .email()
    .required(),
  password: Yup
    .string()
    .min(8)
    .matches(/[0-9]/)
    .matches(/[a-z]/)
    .matches(/[A-Z]/)
    .matches(/[^\w]/)
    .required(),
  confirm: Yup
    .string()
    .required()
    .oneOf([Yup.ref('password')]),
})