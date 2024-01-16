import * as Yup from 'yup'

export default Yup.object({
  email: Yup
    .string()
    .email('Incorrect email')
    .required(),
  password: Yup
    .string()
    .min(8, 'Password must be 8 characters long')
    .matches(/[0-9]/, 'Password requires a number')
    .matches(/[a-z]/, 'Password requires a lowercase letter')
    .matches(/[A-Z]/, 'Password requires an uppercase letter')
    .matches(/[^\w]/, 'Password requires a symbol')
    .required(),
  confirm: Yup
    .string()
    .required()
    .oneOf([Yup.ref('password')], 'Passwords must match'),
})