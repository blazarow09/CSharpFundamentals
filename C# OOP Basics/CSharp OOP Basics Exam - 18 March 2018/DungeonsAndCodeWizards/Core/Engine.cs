switch (nationsType)
            {
                case "Air":
                    foreach (var bender in benders.Where(x => x.GetType().ToString() == $"{nationsType}Bender"))
                    {
                        sb.AppendLine(bender.ToString());
                    }
                    break;
            }