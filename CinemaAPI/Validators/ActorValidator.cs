using CinemaAPI.DTOs;

namespace CinemaAPI.Validators
{
    public class ActorValidator
    {
        public bool ActorPostValidator(ActorPostDTO actorPostDTO)
        {
            if (actorPostDTO.ActorFullName == null)
            {
                throw new System.Exception("ActorFullName is required");
            }
            if (actorPostDTO.ActorHeight != null && actorPostDTO.ActorHeight < 0)
            {
                throw new System.Exception("ActorHeight must be a positive number");
            }

            return true;
        }
    }
}
