export  function UserService( ): void {
    fetch('api/user')
        .then(response => response.json())
        .then(data => console.log(data))
}
export  function FindUserService(id: number ): void {
    fetch(`api/user/${id}`)
        .then(response => response.json())
        .then(data => console.log(data))
}