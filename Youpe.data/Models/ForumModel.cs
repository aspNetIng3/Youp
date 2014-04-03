using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youpe.data.Models
{
    public class ForumModel
    {
        public int Id { get; set; }
        public int Parent_id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<ForumModel> SousForums;

        public static List<ForumModel> getForumsAndSubforums()
        {
            return new List<ForumModel>()
            {
                new ForumModel(){
                    Id = 1,
                    Title = "Vie/Quotidien",
                    Content = "Description",
                    SousForums = new List<ForumModel>(){
                        new ForumModel(){
                            Title = "Etudiant",
                        },
                        new ForumModel(){
                            Title = "Jeunes Parents", 
                        }
                    }
                },
                new ForumModel(){
                    Id = 2,
                    Title = "Jeux",
                    Content = "Description",
                    SousForums = new List<ForumModel>(){
                        new ForumModel(){
                            Title = "Jeux Vidéos"    
                        },
                        new ForumModel(){
                            Title = "Jeux de société"    
                        },
                        new ForumModel(){
                            Title = "Jeux de rôle"    
                        }
                    }
                },
                new ForumModel(){
                    Id = 3,
                    Title = "Activités",
                    Content = "Description",
                    SousForums = new List<ForumModel>(){
                        new ForumModel(){
                            Title = "Parc d'attraction"    
                        },
                        new ForumModel(){
                            Title = "Zoo"    
                        },
                        new ForumModel(){
                            Title = "Bowling"    
                        },
                        new ForumModel(){
                            Title = "Billard"    
                        },
                        new ForumModel(){
                            Title = "Tunning"    
                        },
                        new ForumModel(){
                            Title = "Peinture/dessin"    
                        },
                        new ForumModel(){
                            Title = "Lecture"    
                        }
                    }
                },
                new ForumModel(){
                    Id = 4,
                    Title = "Sports",
                    Content = "Description",
                    SousForums = new List<ForumModel>(){
                        new ForumModel(){
                            Title = "Handball"    
                        },
                        new ForumModel(){
                            Title = "Football"    
                        },
                        new ForumModel(){
                            Title = "Foot en salle"    
                        },
                        new ForumModel(){
                            Title = "Course à pied"    
                        },
                        new ForumModel(){
                            Title = "Paintball"    
                        }
                    }
                },
                new ForumModel(){
                    Id = 5,
                    Title = "Soirée",
                    Content = "Description",
                    SousForums = new List<ForumModel>(){
                        new ForumModel(){
                            Title = "Boîte de nuit"    
                        },
                        new ForumModel(){
                            Title = "Restaurants"    
                        },
                        new ForumModel(){
                            Title = "Cocktail"    
                        },
                        new ForumModel(){
                            Title = "Exposition"    
                        },
                        new ForumModel(){
                            Title = "Vernissage"    
                        }
                    }
                }
            };
        }
    }
}
