namespace MemoTime.Infrastructure.Exceptions
{
    public static class ErrorCodes
    {
        public static string EmailInUse            => "email_in_use";
        public static string UsernameInUser        => "username_in_use";
        public static string InvalidCredentials    => "invlid_credentials";
        public static string ProjectNotExists      => "project_not_exist";
        public static string NoProjectsFound       => "no_projects_found";
        public static string ProjectNotExist       => "project_not_exist";
        public static string TaskNotExist          => "task_not_exist";
        public static string LabelAlreadyExist     => "label_already_exist";
        public static string LabelNotExist         => "label_not_exist";
    }
}